# GGSGEXT
이 프로젝트는 2019년도 정부(과학기술정보통신부)의 재원으로 정보통신기획평가원의 지원을 받아 수행된 프로젝트임 (No.2019-0-01270,스마트 안경을 위한 WISE AR UI/UX 플랫폼 개발)

This work was supported by Institute of Information & communications Technology Planning & Evaluation (IITP) grant funded by the Korea government(MSIT) (No.2019-0-01270, WISE AR UI/UX Platform Development for Smartglasses)

How to test this project?

Install the requirements.
Unity 2020.3.40f1
Microsoft MRTK 2.8.2 & additional requirements for Hololens2 development
Photon PUN2 (at Unity Asset Store)
Build scenes for each device.
Hololens2 (Build Settings = Universal Windows Platform) : NetworkLobby(0), SmartglassConnected(1)
Smartphone (Build Settings = Android) : NetworkLobby(0), SmartphoneConnected(1)
Start the application in both devices.