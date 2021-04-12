import pymongo
from pymongo import MongoClient

cluster = MongoClient("mongodb+srv://mani:1234@cluster0.2bklv.mongodb.net/sample_airbnb?retryWrites=true&w=majority")
db = cluster["sample_airbnb"]
collection = db["Test"]
post = {"_id": 3, "name":"Manish","score":5}
collection.insert_one(post)