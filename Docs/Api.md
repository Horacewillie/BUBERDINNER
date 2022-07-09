# Buber Dinner API

Table of Content
- [Buber Dinner API](#buber-dinner-api)
- [Auth](#auth)
   - [Register](#register)
     - [Register Request](#register-request)
       - [Register Response](#register-response)
    - [Login](#login)
     - [Login Request](#login-request)
       - [Login Response](#login-response)

## Auth

## Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName":"Horace",
    "lastName":"Akpan",
    "email":"horacewillie7@gmail.com",
    "password":"horace2016@"
}
```

#### Register Response

```js
200 OK
```

```json
{
    "id":"tage527a-eb3e-7898-76tfyt56735afg56",
    "firstName":"Horace",
    "lastName":"Akpan",
    "email":"horacewillie7@gmail.com",
    "token":"horace2016@"
}