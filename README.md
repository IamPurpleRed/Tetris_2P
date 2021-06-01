Tetris 2P
===
###### tags:`GitHub`, `schoolwork`, `c#`

// TODO: 圖片待補

## Introduction
**Made by PurpleRed in 2021**

This repository is my personal final project of **"109-2 視窗程式設計"**. The game is based on the popurlar game in Facebook: **Tetris Battle**


## How to Play
// TODO: 待補


## Control
### Player 1: 
* **A/D**: move left/right
* **S**: let the block fall faster
* **B** or **Tab**: hold the block
* **Space** or **Caps Lock**: Straight falling
* Note: **B & Space** for those who prefer using left hand to control the block. **Tab & Caps Lock** for the others.

### Player 2: 
* Not yet :P


## Tools & Environments
**This repository is a Visual Studio 2019 project.**
* Language: Microsoft .NET Framework 4.7.2
* IDE: Microsoft Visual Studio 2019

**Make sure all of the header files & source files be added in the Visual Studio project before compiling on vs2019**


## Release Log
* **version 0.1-beta (2021/05/25):**
    * 基本遊戲架構及排版
    * 視窗大小為 1200*700，但是好像有一點誤差
    * 目前只有1P能遊玩(2P尚未實作)
    * 兩分鐘倒數計時是數好玩的，遊戲實際上是不會結束的，除非你把它關掉
    * 方塊堆到最高也不會Game Over，尚未實作
    * 按鈕只有 **START!** 跟 **EXIT** 有被實作
* **version 0.1.1-beta (2021/05/25):**
    * **上版控 & GitHub**
    * 修正hold之後方塊沒有進行互換，而是一直保持在最先hold的某個方塊
    * 修正**方塊T**在第二型態(72)時，在地圖最左邊旋轉成73會跳出例外狀況(index out of range)
    * 修正**方塊J**在第四型態(64)時，在地圖最左邊旋轉成61會跳出例外狀況(index out of range)
    * 修正2P介面pictureBox的跑版問題(誤差問題真的有點...)
    * 為了讓視覺平衡，更改視窗大小為 1215*700
    * 1P按鍵修正，變得更直覺 & 人性化了 :D
    * Release Log內容改用中文撰寫，因為作者英文太爛
* **version 0.2-beta (2021/05/30):**
    * 添加地雷機制，為了測試壓力條跟地雷，**2P現在會每隔5秒發送2格壓力給1P**
    * 實作KO機制，方塊被疊滿是會被KO的(僅限1P)，2P那邊也會添加KO分數
    * 兩分鐘倒數計時終於有用了，也可以顯示誰輸誰贏(因為2P沒有遊玩，因此只要1P被KO一次就一定會輸)
    * 遊戲結束後，將會有一個按鈕可以回到主畫面(初始狀態)
    * 暫時移掉部分音效，版本確定穩定後會再加回來
    * 這版bug修好久...最好給我沒事
* **version 0.2.1-alpha (2021/05/31):**
    * **重要：這版已知有閃退的大問題，但是發生機率太低且發生時沒有任何相關數據，因此目前無法修正，將會邀請更多玩家來測試**
    * 有一位測試玩家回報1P的快速下降按鍵(S)時不時會卡住，甚至沒有反應，但是我玩得很順暢，因此不確定問題是出在程式上還是測試玩家的設備上，也是會交給更多玩家來測試看看
    * 降低遊戲難度，2P現在改為**每隔8秒發送2格壓力給1P**
    * 修正hold的數值在遊戲重新開始(第二局之後)未被初始化的問題，此漏洞導致新遊戲開始時第一個hold的方塊，會變成上一局遊戲中最後一個hold上去的方塊
    * 放置方塊的音效回來了
    * 修正README檔案資訊錯誤(連這個也會筆誤...)
    * 地雷機制想要還原原作，不過實施難度偏高，考慮開一個新分支試著寫寫看，但是暫不納入正規進度
* **version 0.2.2-beta (2021/06/01):**
    * 為了測試方便，在2P實作之前，**1P的WSAD鍵位暫時分別以上下左右鍵代替**
    * 修正1P在按下**方塊快速下降鍵(S，目前為下鍵)**的同時被KO之後，1P方塊下降速率沒有回到正常速度的問題
    * 修正receiveMine函式中，新增的地雷數計算結果可能會產生負整數的情況，此漏洞導致在重新繪製grids時會跳出例外狀況(index out of range)