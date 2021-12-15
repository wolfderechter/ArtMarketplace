node('ProductieServer') {
    stage('Preparation') {
        build 'Productie_Cleanup'
        build 'Productie_pull_github'
        build 'Productie_inject_dockerfiles'
    }
    stage('Build') {
        build 'Productie_buildWebApp'
    }
}
