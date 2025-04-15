pipeline {
    agent any

    environment {
        NODE_ENV = 'production'
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
                    ./dotnet-install.sh --channel 8.0 --install-dir $HOME/dotnet
                    export PATH=$HOME/dotnet:$PATH

                    dotnet build
                    if [ "$TEST" = "true" ]; then
                        dotnet test
                    fi
                '''
            }
        }
    }
}
