import json
import requests
import openpyxl
from json2xml import json2xml


def json_serializer(obj):
    with open('data.json', 'w', encoding='utf-8') as outfile:
        json.dump(obj, outfile, indent=3, ensure_ascii=False)
        
def xlsx_to_json(file):
    book = openpyxl.Workbook()
    sheet = book.active


def xlsx_serializer(obj):
    book = openpyxl.Workbook()
    sheet = book.active
    sheet['A1']="ProductId"
    sheet['B1']="Language"
    sheet['C1']="Description"
    row = 2
    for item in obj: 
        sheet[row][0].value = item['ProductId']
        sheet[row][1].value = item['Language']
        sheet[row][2].value = item['Description']
        row+=1
        
    book.save("data.xlsx")
    book.close()
  
     
def xml_serializer(obj):
    with open('data.xml', 'w', encoding='utf-8') as outfile:
        info = json2xml.Json2xml(obj, wrapper="ProductDescriptions", pretty=True, attr_type=False).to_xml()
        newstr = str(info).replace('item','ProductDescription')
        outfile.write(newstr) 
 
             
        
response = requests.get(
    "https://buildlease.rigorich.monster/api/ProductDescriptions")

json_serializer(response.json())
xlsx_serializer(response.json())
xml_serializer(response.json())

# requests.post("https://buildlease.rigorich.monster/api/ProductDescriptions",file)

# print(response.json())
