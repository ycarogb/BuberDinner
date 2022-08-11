#Buber Diner API

- [Buber Dinner API](#buber-dinner-api)
    - [Auth](#auth)
        - [Register](#register)
        - [Register Request](#register-request)
        - [Register Request](#register-response)
    - [Login](#login)
        - [login Request](#login-request)
        - [login Request](#login-response)

## Auth

## Register

```js
POST {{host}}/auth/register
```

### Register Request
```json
{ 
    "firstname": "João",
    "lastname": "da Silva",
    "email": "joaodasolva@gmail.com",
    "password": "joao123"
}
```

### Register Response 

```js
200 OK
```

```json
{
    "id" : "1",
    "firstname": "João",
    "lastname": "da Silva",
    "email": "joaodasolva@gmail.com",
    "token": "tyJhb.x9bj"
}