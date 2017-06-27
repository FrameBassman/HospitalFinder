properties([pipelineTriggers([githubPush()])])

node {
    git url: 'https://github.com/FrameBassman/HospitalFinder.git', branch: 'master'
    stage 'Docker cleanup'
        sh 'echo 1'
}
