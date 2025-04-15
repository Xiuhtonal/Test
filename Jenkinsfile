pipeline {
    agent any

    environment {
        NODE_ENV = 'production'
        DOTNET_SYSTEM_GLOBALIZATION_INVARIANT = '1'
    }

    parameters {
        booleanParam(name: 'SAVE_ARTIFACT', defaultValue: true, description: 'Save artifact?')
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
                    dotnet run
                '''
            }
        }
        stage('Report') {
            steps {
                copyArtifacts(
                    projectName: 'source-job-name',
                    selector: lastSuccessful(),
                    filter: 'build/output.txt',
                    target: 'copied-artifacts/'
                )

                sh '''
                    if [ "$SAVE_ARTIFACT" = "true" ]; then
                        archiveArtifacts artifacts: 'build/output.txt', fingerprint: true
                        
                        cat copied-artifacts/build/output.txt
                    fi
                '''
            }
        }
    }
}