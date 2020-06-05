
# **API PROJECT / INSTITUTE**

App EntityFrameworck Core Api, ABM of students / teachers with local database.

## **PRE-REQUIREMENTS**

- SQLServer 2017 express
- Visual Studio 2017 
	.Net Core 2.2

## **APIs Summary**

**Methods used to invoke APIs**

**GET**

* *to search for resources / details* *

**POST**

* *to create new resource 

**PUT**

* *to change details of that resource* *

**PATCH**

* *to change partial details of that resource* *

**DELETE**

* *to delete resource* *

## **How to make use of the API?**

* *The API can be invoked through HTTP GET, POST, PUT and PATCH requests.
All parameters in the request must be encoded by form.* *

supports the JSON format and the URL structure for it is given below:
```
URL

https://<Host-Name OR IP address>:<Port>/api/students/<Resource ID>
```

##GET LIST OF RESOURCES

Description

* *To get the list of resources which are owned by or shared to an API user.* *
```
URL

https://<Host-Name OR IP address>:<Port>/api/students/

```

**HTTP Method**

GET

**Input Data**

None

**Sample Output**

In the output (as shown in the sample below), you will get all the resources owned

```
example
{
  
  "name" : "Rick " ,

  "surname " : "Sanchez",

  "course" : "C",

  "telephone" : "1155234567",

  "email": "a@a.com",
 
  "studentID": "22"
                              
},
{
  
  "name" : "Ines " ,

  "surname " : "Stevez",

  "course" : "A",

  "telephone" : "1155244323",

  "email": "abc@a.com",
 
  "studentID": "23"
                              
},
{
  
  "name" : "Stella " ,

  "surname " : "Rico",

  "course" : "B",

  "telephone" : "1155767667",

  "email": "dfg@a.com",
 
  "studentID": "23"
                              
},

...

```

**GET THE DETAIL OF A PARTICULAR RESAOURCE

Description

* *To obtain the detail of a resource, in an http request platform, it is necessary
to have its id (obtained in the GET method of the resource list)* *


* *Sample Request* *
```
URL

https://<Host-Name OR IP address>:<Port>/api/students/<Resource ID>
```

**HTTP Method**

GET

**Input Data**

Resource ID

* *Sample Output* *
```
example recourseId : 23


  "name" : "Stella " ,

  "surname " : "Rico",

  "course" : "B",

  "telephone" : "1155767667",

  "email": "dfg@a.com",
 
  "studentID": "23"

```

**ADD A RESOURCE

Description

* *To add a resource, you must enter the resource form in an http request platform in json format* *

* *Sample Request* *
```
URL

https://<Host-Name OR IP address>:<Port>/api/students/
```

**HTTP Method**

POST

**Input Data**

in json format, you must enter the resource form(the properties of the resource)
```
{
  "name" : "value1 " ,

  "surname " : "value2",

  "course" : "value3",

  "telephone" : "value4",

  "email": "value5"
}
```

* *Sample Output* *
```
{
  "name" : "value1 " ,

  "surname " : "value2",

  "course" : "value3",

  "telephone" : "value4",

  "email": "value5",

  "studentID": "new Id"
}

```

**MODIFY AN ENTIRE RESOURCE

Description

* *To modify a complete resource, on an http request platform, you must enter the resource id in 
the url and the resource form in json format in the body of the request* *


* *Sample Request* *
```
URL

https://<Host-Name OR IP address>:<Port>/api/students/<Resource ID>
```

**HTTP Method**

PUT

**Input Data**

get the resource using the id and then modify it with the new data in json format, 
you need to enter the resource form (the resource properties)
```
example:

{
  "name" : "Stella " ,

  "surname " : "Rico",

  "course" : "B",

  "telephone" : "1155767667",

  "email": "dfg@a.com",
 
  "studentID": "23"
}

modified with new data

{
  "name" : "newValue1 " ,

  "surname " : "newValue2",

  "course" : "newValue3",

  "telephone" : "newValue4",

  "email": "newValue5"
  
*"studentID" no modification necessary
}
```

* *Sample Output* *
```
{
  "name" : "newValue1" ,

  "surname " : "newValue2",

  "course" : "newValue3",

  "telephone" : "newValue4",

  "email": "newValue5",

  "studentID": "23"
}

```

**MODIFY AN PARTIAL RESOURCE

Description

* *To modify a partial resource, on an http request platform, you must enter the resource id in 
the url and using a patchdocument replace the property of that record* *


* *Sample Request* *
```
URL

https://<Host-Name OR IP address>:<Port>/api/students/<Resource ID>
```

**HTTP Method**

PATCH

**Input Data**

obtain the resource using the identification and then using json format, you must enter 
the operation / where the patch will be / the value
```
example:
]
    {
	"op" : "Replace" ,
	"path " : "/surname",
 	"value" : "Collins"
    }
]

```

* *Sample Output* *
```
{
  "name" : "Stella " ,

  "surname " : "Collins",

  "course" : "B",

  "telephone" : "1155767667",

  "email": "dfg@a.com",
 
  "studentID": "23"
}

```

**DELETE RESOURCE

Description

* *To delete a resource, on an http request platform, you must search for the resource 
using the id and then delete them with that request.* *


* *Sample Request* *
```
URL

https://<Host-Name OR IP address>:<Port>/api/students/<Resource ID>
```

**HTTP Method**

DELETE

**Input Data**

Resource ID

* *Sample Output* *
```
NoContent

```





