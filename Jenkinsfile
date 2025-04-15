pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:8.0'
        }
    }

    environment {
        NODE_ENV = 'production'
    }

    parameters {
        booleanParam(name: 'TEST', defaultValue: true, description: 'Test New Code?')
    }

    stages {
        stage('Build') {
            steps {
                sh '''
                dotnet build
                '''
            }
        }
        stage('Test') {
            when {
                expression { params.TEST }
            }
            steps {
                sh '''
                dotnet test
                '''
            }
        }
    }
}