
# Product Api

A simple service to add and retrieve products via a public endpoint.

*P.S. (not) production ready*


## How to install
Please disregard below steps if already installed
***

- Download and install .NET Core v3.1
https://dotnet.microsoft.com/en-us/download/dotnet/3.1

**Disclaimer I had v3.1 already installed, limitations and exclusions for newer versions as it has not been tested**

*Yes yes, I know I know it's my responsibility (my bad)*

- Download and install Visual Studio Community (VS)
https://visualstudio.microsoft.com/downloads/
***

## Installation

1) Clone repository
- using [GitHub](https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository?tool=webui) *(highly recommend SourceTree)*
- if unsure [ChatGPT](https://openai.com/blog/chatgpt/) would be able to assist you

2) Once cloned successfully, navigate to the downloaded folder path

3) Click on productApi folder, you should see folder structure:
```
.
├── productAPI
├── .gitattributes
├── .gitignore
└── .productAPI.sln
```

2) Go ahead and click on *.productAPI.sln* and it should open VS program **if installed correctly*

3) On the navigation bar, select Build -> Build solution.

```bash
Build started...
1>------ Build started: Project: productAPI, Configuration: Debug Any CPU ------
1>C:\Users\ksanmugam\source\repos\productAPI\productAPI\Product\Services\ProductService.cs(7,7,7,26): warning CS0105: The using directive for 'productAPI.Entities' appeared previously in this namespace
1>C:\Users\ksanmugam\source\repos\productAPI\productAPI\Product\Services\ProductService.cs(65,30,65,31): warning CS0168: The variable 'e' is declared but never used
1>productAPI -> C:\Users\ksanmugam\source\repos\productAPI\productAPI\bin\Debug\netcoreapp3.1\productAPI.dll
1>Done building project "productAPI.csproj".
========== Build: 1 succeeded, 0 failed, 0 up-to-date, 0 skipped ==========

```

4) If successful, you should see above in terminal, go ahead and press F5 to start debugging

5) Happy days
    
## Testing
*To seed dummy data, navigate to Startup.cs in VS and uncomment code on line 61 (CTRL + K + U) you're welcome*

### GET
To run tests, navigate to `https://localhost:<port>/product` to retrieve products data

Alternatively, Postman API Platform would do *ensure you have installed [Postman Desktop Agent](https://www.postman.com/downloads/postman-agent/)*

### POST
#### Option 1
1) To run tests, navigate to `https://localhost:<port>/product` to retrieve products data.
2) Go to `https://localhost:<port>/swagger/index.html`
3) You should see below image
4) Click on *GET/Product* row
![sample](https://iili.io/HEImMFa.png)

5) Click on *Try it out*. You should see an *Execute* button. 
*ids parameter is optional*

6) Click on *Execute*, products *if any* should appear in the response
7) 
To search for a product, enter *product id* into the *ids* parameter.

To search for more than one product, enter each *product id* followed by `,` after each *product id*
Example `1ade77b6-9929-4939-8592-c4e8336749c9,3fa85f64-5717-4562-b3fc-2c963f66afa6`

You should see response as below 
```bash
[
  {
    "id": "1ade77b6-9929-4939-8592-c4e8336749c9",
    "name": "Bundaberg",
    "description": "ginger",
    "price": 2.99
  },
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "Coca-Cola 600ml",
    "description": "Best mixer for spirits",
    "price": 1.25
  }
]
```

#### Option 2
1) Go to [Postman](https://www.postman.com/) *create an account it's free*
2) Create a new workspace
3) Click on + to open a new request, select POST and enter request URL `https://localhost:<port>/product`
4) Select Body, click on raw and select JSON on the dropdown list
5) Insert code below into body *(id is optional)*
Feel free to replace "string" with characters and don't forget to set your price (nothing is free). To add more than one product, use the same format in tag {} with comma separated
```bash
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "string",
    "description": "string",
    "price": 0
  }
  ...
]
```
6) If response as below
```bash
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.13",
    "title": "Unsupported Media Type",
    "status": 415,
    "traceId": "|2252bcb-4726c36da7566027."
}
```
*it means you're not COMPLYING and you forgot to change `Text` to `JSON`*

7) If successful, you should receive response as below 
```bash
{
    "success": true,
    "error": "Successfully added product(s)"
}
```
If you're reached this far, give yourself a pat on the back! Well done! Look forward to working with you



