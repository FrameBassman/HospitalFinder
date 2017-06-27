properties([pipelineTriggers([githubPush()])])

node {
    git url: 'https://github.com/FrameBassman/HospitalFinder.git', branch: 'master'
    stage 'Checkout'
        git branch: 'dev', credentialsId: 'github-creds', url: 'https://github.com/WalletCSI/wallet.git'
    stage 'Docker cleanup'
        sh 'make docker-cleanup -i'
    stage 'Build'
        sh 'make build'
    stage 'Run for testing'
        sh 'make start-test'
    stage 'Test'
        sh 'echo tests coming soon...'
    input 'Do you approve stop?'
    stage 'Stop'
        sh 'make stop'
}
