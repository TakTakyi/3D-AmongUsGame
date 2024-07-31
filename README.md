3D 어몽어스 개발 문서

디렉토리 구조 (파일 구조)

01.scene
- 씬 폴더
- Dev 개발폴더
    - NoMult 포톤을 적용하지 않는 폴더
          - Game Scene 퀘스트 구현용 씬
          - Lobby Scene 로비씬 
    - Photon 포톤을 적용하는 폴더
        - PhotonGameScene 포톤 서버를 적용할 게임씬
        - TitleScene 로그인 및 회원가입용 씬
- Release 배포용 폴더

02.scripts 
- 스크립트 폴더 
- 설계를 다시 해야함
- 클래스별 설명 (해당 클래스이름 - 간단 설명으로 작성 클래스이름을 보고 파악하기 위해 나머지 세세한 내용은 클래스를 열어서 확인) 추가 필요


03.prefab 
- 프리팹 폴더
- 퀘스트 및 맵에 배치될 사물 

04.ExResources
- 리소스 폴더 
- 에셋들을 모아둔 폴더

05.matrials
- 스카이 박스 머터리얼 (배경)
- 이미지 머터리얼

06.sounds
- 사운드 폴더

07.image
- 이미지 폴더
- 퀘스트용 이미지
- UI용 이미지 

08.anim
- 애니메이션 폴더

photon
- 포톤 엔진 폴더
- 멀티 플레이를 위한 서드파티 엔진

Resources - 아웃라인 쉐이더 폴더 

주요 변경점 (날짜를 기준으로 작성, 에셋추가 및 기능 구현 완료)
2024년 7월 8일 포톤 엔진 추가

개발 순서 정하기

1. 포톤 구현 하기 - 서버접속 > 방만들기및 방검색 > 방참가 > 게임시작후 플레이어 캐릭터가 움직임이 가능하게
2. 미션 구현 하기 - 미션관리및 서버연결해야할 미션인지 판단 필요
3. 게임 규칙 구현 - 채팅 및 마피아정하기 및 게임종료 기능 구현 필요 

