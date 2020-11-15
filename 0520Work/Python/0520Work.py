# -*- coding: utf-8 -*-
"""
Created on Tue May 14 09:26:09 2019

@author: user
"""

#---------------- 從cmd執行該程式，並帶入參數---------------------
import argparse 
p=argparse.ArgumentParser()
p.add_argument('--isbn',required=False,default='')
args=p.parse_args()
isbn = args.isbn
#---------------------------------------------------------------

from selenium import webdriver
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions
from selenium.webdriver.common.by import By

path ='C:\chromedriver.exe'
url='https://feebee.com.tw/'
driver=webdriver.Chrome(executable_path=path)
driver.get(url)

search = driver.find_element_by_id('search') #查詢方塊
search.send_keys(isbn) #9789861371955
search.submit()

#for submit in driver.find_elements_by_class_name('pure-u'): #搜尋按鈕
#    if submit.text == '搜尋':
#        submit.click()

try:
    WebDriverWait(driver,10).until(expected_conditions.presence_of_element_located((By.ID,'search_result')))
    print('已執行完畢')
except Exception as e:
    print('中斷',e)
else:
    from bs4 import BeautifulSoup
    sp = BeautifulSoup(driver.page_source,'lxml')
    
    noResult = sp.find_all('div',{'class':'no-result small'})
    if noResult: #list本身如果為空，就會傳回false。做壞了
        print('--分割--','noResult','--分割--')
    else:
        name = sp.select('#list_view li h3')
        price = sp.find_all('span',{'class':'price ellipsis xlarge'})
        shop = sp.find_all('span',{'class':'shop'})
        link = sp.select('#list_view li a')
        link_img = sp.select('#list_view li img')
        
        print('--分割--',name[0].text,'--分割--')
        print('--分割--',price[0].text,'--分割--')
        print('--分割--',shop[0].text.strip().replace(' ',''),'--分割--')
        print('--分割--',link[0]['href'],'--分割--')
        print('--分割--',link_img[0]['src'],'--分割--')
    driver.quit()
