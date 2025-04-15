pipeline {
    agent any

    environment {
        NODE_ENV = 'production'
        DOTNET_SYSTEM_GLOBALIZATION_INVARIANT = '1'
    }

    parameters {
        booleanParam(name: 'TEST', defaultValue: true, description: 'Test New Code?')
    }

    stages {
        stage('Build and Test') {
            steps {
                sh '''
                    curl -sSL https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh
                    chmod +x dotnet-install.sh
                    ./dotnet-install.sh --channel 9.0 --install-dir $HOME/dotnet
                    export PATH=$HOME/dotnet:$PATH

                    dotnet build
                    if [ "$TEST" = "true" ]; then
                        dotnet run
                    fi
                '''
            }
        }
    }
}
