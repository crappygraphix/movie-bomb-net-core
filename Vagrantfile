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

  config.vm.provision 'shell',
      path: 'vagrant/provision.sh',
      privileged: false,
      binary: true
end
