ReservationsCREATE SCHEMA `SQLModel` ;

USE SQLModel;

CREATE TABLE Reservations (
         ReservationNumber INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
         FirstName VARCHAR(45),LastName VARCHAR(45),Occupants INT,Smoking INT,CheckIn DATETIME,CheckOut DATETIME,Requests TEXT );

