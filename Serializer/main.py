import json
import requests
from json2xml import json2xml
import pandas as pd


def json_serializer(obj, file='data.json'):
    with open(file, 'w', encoding='utf-8') as outfile:
        json.dump(obj, outfile, indent=3, ensure_ascii=False)


def xlsx_to_json(file, outputfile="import.json"):
    df = pd.read_excel(file)
    json_str = df.to_json(orient='records')
    parsed = json.loads(json_str)
    json_serializer(parsed, outputfile)


def xlsx_serializer(obj, file="data.xlsx"):
    print(obj)
    df = pd.DataFrame(obj)
    df.to_excel(file)


def xml_serializer(obj, file="data.xml"):
    with open(file, 'w', encoding='utf-8', ensure_ascii=False) as outfile:
        info = json2xml.Json2xml(
            obj, wrapper="ProductDescriptions", pretty=True, attr_type=False).to_xml()
        newstr = str(info).replace('item', 'ProductDescription')
        outfile.write(newstr)


def POST_request(file="import.json"):
    with open(file, "r", encoding='utf-8') as file:
        json_data = json.load(file)

    headers = {'Accept': 'application/json',
               'Content-Type': 'application/json', 'charset': 'utf-8'}
    requests.post("https://buildlease.rigorich.monster/api/ProductDescriptions",
                  data=json.dumps(json_data), headers=headers)
    assert response.status_code == 200


response = requests.get(
    "https://buildlease.rigorich.monster/api/ProductDescriptions")
print(response.status_code)


json_serializer(response.json())
xlsx_serializer(response.json())
xml_serializer(response.json())
xlsx_to_json("import.xlsx")
POST_request()
