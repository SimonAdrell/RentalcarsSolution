# RentalcarsSolution

## Start

To get the database to start.

```
dotnet tool install -g dotnet-ef
cd RentalCarService.Api\
dotnet ef database update
```

Then start debug from visual studio to get the beautiful SwaggerUi. 


##Swager:

### GET Booking 
Used to ge all bookings.

### POST Booking
Use to create a new booking, use Rental registration model, Ex: 
```
{
  "regnr": "CPR100",
  "bookingNumber": "1",
  "customerDateOfBirth": "1212121212",
  "carCategory": "Minivan",
  "currentMilage": 1200
}
```

### GET Booking/{bookingNumber}
To get specific booking


## POST CarReturn
Used return active booking, returnes preice of the rental. 
```
{
  "bookingNumber": "1",
  "currentMilage": 1500
}

```

## Cars. 

To create and edit cars used for rental registration. 



## Test
  
RentalCarService.api tested with RentalCarsService.test easiet way to test is with this command: 

```
dotnet test
```



