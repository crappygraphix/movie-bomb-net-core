#!/bin/bash
set -e -u -x

hab_version="0.72.0"
hab_origin="crappygraphix"

function os_bootstrap
{
  export LANGUAGE=en_US.UTF-8
  export LANG=en_US.UTF-8
  export LC_ALL=en_US.UTF-8
  sudo locale-gen en_US.UTF-8
  sudo dpkg-reconfigure locales -f noninteractive
  wget -q https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb
  sudo dpkg -i packages-microsoft-prod.deb
  sudo apt-get update
  sudo apt-get install -y unzip automake autoconf libreadline-dev libncurses5-dev libssl-dev libyaml-dev libxslt-dev libffi-dev libtool unixodbc-dev build-essential inotify-tools bash-completion
}

function dotnet_bootstrap
{
  sudo apt-get install -y apt-transport-https
  sudo apt-get install -y dotnet-sdk-2.2
}

function node_bootstrap
{
  wget -qO- https://raw.githubusercontent.com/nvm-sh/nvm/v0.34.0/install.sh | bash
  . /home/vagrant/.nvm/nvm.sh
  nvm install 10.15.3
  npm install -g uglify-js
}

function sass_bootstrap
{
  wget https://github.com/sass/dart-sass/releases/download/1.20.1/dart-sass-1.20.1-linux-x64.tar.gz -P ~/
  tar -xvf ~/dart-sass-1.20.1-linux-x64.tar.gz --directory ~/
  sudo mv ~/dart-sass/* /usr/local/bin
  rm -rf ~/dart-sass
  rm ~/dart-sass-1.20.1-linux-x64.tar.gz
}

function hab_bootstrap
{
  if command -v hab; then
    echo "Habitat already installed"
  else
    # Install habitat
    curl -o hab_install.sh https://raw.githubusercontent.com/habitat-sh/habitat/master/components/hab/install.sh

    sudo bash ./hab_install.sh -v ${hab_version}

    sudo hab pkg install core/hab-sup/${hab_version}
    sudo hab pkg install core/hab-launcher

    sudo groupadd hab || true
    sudo useradd -g hab hab || true
  fi
}

function hab_origin_setup
{
  hab origin key generate ${hab_origin}
  hab origin key export ${hab_origin} --type public | sudo hab origin key import
}

function hab_profile
{
  rm -f /home/vagrant/.hab/etc/cli.toml

  export HAB_ORIGIN="${hab_origin}"

  sudo tee /etc/profile.d/hab.sh << EOF
export HAB_ORIGIN="${hab_origin}"
EOF
}

function hab_sup
{
  # Start supervisor
  sudo tee /etc/systemd/system/hab-sup.service << EOF
[Unit]
Description=The Habitat Supervisor

[Service]
ExecStart=/bin/hab sup run
Restart=on-failure

[Install]
WantedBy=default.target
EOF

  sudo systemctl enable hab-sup
  sudo systemctl start hab-sup

  sleep 10
}

function hab_db
{
  # Run postgresql under habitat, so we have a DB server in the dev env
  # Start postgresql
  sudo hab svc load core/postgresql

  # Alias common postgresql commands
  sudo tee /usr/local/bin/psql <<EOF
#!/bin/sh
hab pkg exec core/postgresql psql "\$@"
EOF
  sudo chmod +x /usr/local/bin/psql
}

os_bootstrap
dotnet_bootstrap
node_bootstrap
sass_bootstrap

hab_bootstrap
hab_origin_setup
hab_profile
hab_sup
hab_db
