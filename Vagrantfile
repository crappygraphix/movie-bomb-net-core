Vagrant.configure('2') do |config|
  config.vm.box = "bento/ubuntu-16.04"
  config.vm.hostname = 'movie-bomb-net-core'
  config.vm.network 'private_network', ip: '172.28.128.200'

  config.vm.provider 'virtualbox' do |v|
    v.memory = 2048
    v.cpus = 2
    v.customize ["modifyvm", :id, "--audio", "none"]
    v.customize ["modifyvm", :id, "--vrde", "off"]
    v.customize ["guestproperty", "set", :id, "--timesync-threshold", 1000]
  end

  config.vm.synced_folder '.', '/vagrant', disabled: true
  config.vm.synced_folder '.', '/src'

  config.vm.network 'forwarded_port',
    guest: 5623,
    host: 5623

  config.vm.provision "shell", inline: <<-SHELL
    export DEBIAN_FRONTEND=noninteractive
    export LANGUAGE=en_US.UTF-8
    export LANG=en_US.UTF-8
    export LC_ALL=en_US.UTF-8
    locale-gen en_US.UTF-8
    dpkg-reconfigure locales
    wget -q https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    sudo apt-get update
    sudo apt-get install -y apt-transport-https

    sudo apt-get install -y dotnet-sdk-2.2
    sudo apt-get install -y unzip automake autoconf libreadline-dev libncurses5-dev libssl-dev libyaml-dev libxslt-dev libffi-dev libtool unixodbc-dev build-essential inotify-tools bash-completion

    wget -qO- https://raw.githubusercontent.com/nvm-sh/nvm/v0.34.0/install.sh | bash
    . /home/vagrant/.nvm/nvm.sh
    nvm install 10.15.3
    npm install -g uglify-js

    wget https://github.com/sass/dart-sass/releases/download/1.20.1/dart-sass-1.20.1-linux-x64.tar.gz -P ~/
    tar -xvf ~/dart-sass-1.20.1-linux-x64.tar.gz --directory ~/
    sudo mv ~/dart-sass/* /usr/local/bin
    rm -rf ~/dart-sass
    rm ~/dart-sass-1.20.1-linux-x64.tar.gz

    sudo apt-get install -y postgresql postgresql-contrib
    sudo -u postgres psql -c "ALTER USER postgres PASSWORD 'postgres';"
  SHELL
end
