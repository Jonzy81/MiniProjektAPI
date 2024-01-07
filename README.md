# Miniprojekt: API

## Details
This project was created for me to test and build my first simple Webb-API. It uses Rest-architecture that anebles external services and applications to **GET** and **POST** data in my application

## Assignment Details

The following endpoints can be used to interact with the API, dont forget to use base URL:

**Add new user to database:**   
    POST /user

**List all users:**   
    GET /user/member

**Add new interest to database:**   
    POST /user/{id}/interest

**Show user interest:**   
    GET /user/{id}

**Assign user interest:**   
    POST /user/{personId}/interest{interestId}

**Assign user interest to database:**   
    POST /user/{personId}/interest/{interestId}/links

**Show user links:**   
    GET /user/{id}/links

___

      
![My Diagram](APIflödesDiagrambild.drawio.svg)

---

![My Diagram](Namnlöst diagram.drawio.svg)
