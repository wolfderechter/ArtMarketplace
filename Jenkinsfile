node('ProductieServer') {
    stage('Build') {
        build 'Productie_dotnet_test'
    }
    stage('Deploy') {
        build 'Productie_Cleanup'
        build 'Productie_pull_github'
        build 'Productie_inject_dockerfiles'
        build 'Productie_buildWebApp'
        
    }
}
