pipeline {
    agent any

    environment {
        NODE_ENV = 'production'
        API_KEY = credentials('api-key-id')
    }

    parameters {
        booleanParam(name: 'TEST', defaultValue: true, description: 'Test New Code?')
    }

    stages {
        stage('Build') {
            steps {
                sh '''
                docker build -t dotnet-test-image .
                '''
            }
        }
        stage('Test') {
            steps {
                script {
                    if (params.TEST == true) {
                        sh '''
                        docker run -d -p 1000:1000 --name jenkins-dotnet-test dotnet-test-image
                        '''
                    }
                }
            }
        }
    }
}