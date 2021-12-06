node('AcceptatieServer') {  
    stage('Prepare') { 
        build 'Acceptatie_cleanup'
        build 'Acceptatie_pull_github' 
        build 'Acceptatie_inject_dockerfiles' 
    }
    stage('Build') { 
        build 'Acceptatie_buildWebApp'
    }
}
