# 線上自動比價網站
> _大四下_友鋒課作業_   

* 功能說明
  1. 輸入書籍ISBN，可自動在`飛比價格`中搜尋並篩選出最便宜的賣場
 
* 使用技術
  1. ASP.NET MVC
  2. C#
  3. javascript
  4. python  
  
* 程式架構
  |        | 說明 |程式 |
  |------- |:-----|:------:|
  | **前端**   |  1. 只有一個頁面，使用`Razor語法`判斷後端是否有傳送賣場書籍資訊。</br>2. JS顯示Loading遮罩效果。  |  [程式碼](https://github.com/hank444tw/0520Work/blob/master/0520Work/Views/Home/NFU.cshtml) |
  | **後端**   |  1. 執行`cmd`呼叫對應的python檔案。</br>2. 接收python檔案回傳值，並以串列型態回傳前端。  |  [程式碼](https://github.com/hank444tw/0520Work/blob/master/0520Work/Controllers/HomeController.cs) |
  | **python** |  1. 使用`Selenium 3.141`搭配`ChromeDriver`實現網頁自動操作。</br>2. 使用`BeautifulSoup4 4.7.1`針對已搜尋完畢的頁面，第一筆(最便宜)進行爬蟲。  |   [程式碼](https://github.com/hank444tw/0520Work/blob/master/0520Work/Python/0520Work.py) |     

* 網站截圖
<img src="https://github.com/hank444tw/0520Work/blob/master/banner1.JPG" stryle="float:right" />  

<img src="https://github.com/hank444tw/0520Work/blob/master/banner.JPG" stryle="float:right" />
