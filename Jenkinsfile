pipeline {
  agent {
    docker {
      image 'microsoft/aspnetcore-build:2.0'
    }
  }

  environment {
     WORK_DIR = '.'
  }

  stages {
    stage('Build') {
      steps {
        dir('$WORK_DIR') {
          sh './generate'
          sh 'dotnet restore'
          sh 'dotnet build'
        }
      }
    }
    stage('Test') {
      steps {
        dir('$WORK_DIR') {
          sh './runtests'
        }
      }
    }
    stage('Deploy') {
      steps {
        dir('$WORK_DIR') {
          sh './deploy'
        }
      }
    }
  }

  post {
    always {
      dir("${WORK_DIR}") {
        step([$class: 'MSTestPublisher', testResultsFile:"**/*.trx", failOnError: true, keepLongStdio: true])
      }
    }
  }
}
