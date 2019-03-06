
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author Alex
 */
public class DBMethods {

    boolean addReservation(Reservation reservation) {
//Creating required SQL Objects
        Connection conn = null;
        PreparedStatement pstmt = null;
        int itemsadded = 0;
        try {
//Create SQL Connection
            conn = DBConnectionFactory.getConnection();
//Create SQL Statement
            String sql = "INSERT INTO Reservations (FirstName,LastName,Occupants,Smoking,CheckIn,CheckOut,Requests) VALUES (?,?,?,?,?,?,?)";
            pstmt = conn.prepareStatement(sql);
//Inserting variables into SQL Prepared Statment
            pstmt.setString(1, reservation.getFirstName());
            pstmt.setString(2, reservation.getLastName());
            pstmt.setInt(3, reservation.getOccupants());
            pstmt.setInt(4, reservation.getSmoking());
            pstmt.setString(5, reservation.getCheckIn());
            pstmt.setString(6, reservation.getCheckOut());
            pstmt.setString(7, reservation.getRequests());
//execute update and check result 
            itemsadded = pstmt.executeUpdate();
        } catch (Exception e) {
            System.out.println("some error" + e.getMessage());

        } finally {
            DBConnectionFactory.close(conn);
            DBConnectionFactory.close(pstmt);

        }
        return (itemsadded > 0);
    }

//Method for Removing Reservation
    boolean removeReservation(int reservationNumber) {
//Creating required SQL Objects
        Connection conn = null;
        PreparedStatement pstmt = null;
        int itemsremoved = 0;
        try {
//Create SQL Connection            
            conn = DBConnectionFactory.getConnection();
//Create SQL Statement           
            String sql = "DELETE FROM Reservations WHERE ReservationNumber = ?";
            pstmt = conn.prepareStatement(sql);
//Insert variables into prepared Stamtnet
            pstmt.setInt(1, reservationNumber);
//Execute update
            itemsremoved = pstmt.executeUpdate();



        } catch (Exception e) {
            System.out.println("some error" + e.getMessage());

        } finally {
            DBConnectionFactory.close(conn);
            DBConnectionFactory.close(pstmt);

        }


        return (itemsremoved > 0);


    }

    
    
    
    
    
//Get all reservations method    
    ArrayList<Reservation> getReservations() {
//Create required objects and array list
        ArrayList<Reservation> reservationlist = new ArrayList<Reservation>();
        ResultSet rs = null;
        PreparedStatement pstmt = null;
        Connection conn = null;

        try {
//Create SQL connection            
            conn = DBConnectionFactory.getConnection();
//SQL STring 
            String sql = "Select * from Reservations";


            pstmt = conn.prepareStatement(sql);
            rs = pstmt.executeQuery();
//Create loop to create all reservation objects and add them to array list
            while (rs.next()) {

                reservationlist.add(new Reservation(rs.getInt("ReservationNumber"),
                        rs.getString("FirstName"),
                        rs.getString("LastName"),
                        rs.getInt("Occupants"),
                        rs.getInt("Smoking"),
                        rs.getString("CheckIn"),
                        rs.getString("CheckOut"),
                        rs.getString("Requests")));

            }

        } catch (Exception e) {
            System.out.println("some error" + e.getMessage());

        } finally {
            DBConnectionFactory.close(conn);
            DBConnectionFactory.close(pstmt);
            DBConnectionFactory.close(rs);

        }


        return reservationlist;

    }

    
    
//Method for getting reservation based on reservation number    
    Reservation getReservation(int reservationNumber) {


//Create required objects
        ResultSet rs = null;
        PreparedStatement pstmt = null;
        Connection conn = null;
        Reservation ReservationRN = null;


        try {
//create SQL Connection
            conn = DBConnectionFactory.getConnection();
//Create SQL String
            String sql = "Select * FROM Reservations WHERE ReservationNumber = ?";
            pstmt = conn.prepareStatement(sql);
            pstmt.setInt(1, reservationNumber);

            rs = pstmt.executeQuery();
            rs.next();

//Create new reservation Object based on reservation number
           
            ReservationRN = new Reservation(rs.getInt("ReservationNumber"),
                    rs.getString("FirstName"),
                    rs.getString("LastName"),
                    rs.getInt("Occupants"),
                    rs.getInt("Smoking"),
                    rs.getString("CheckIn"),
                    rs.getString("CheckOut"),
                    rs.getString("Requests"));


        } catch (Exception e) {
            System.out.println("some error" + e.getMessage());

        } finally {
            DBConnectionFactory.close(conn);
            DBConnectionFactory.close(pstmt);
            DBConnectionFactory.close(rs);

        }

        return ReservationRN;

    }

    
//Method for getting reservation based on last name   
    Reservation getReservation(String LastName) {


//Create Required Objects
        ResultSet rs = null;
        PreparedStatement pstmt = null;
        Connection conn = null;
        Reservation ReservationRN = null;


        try {
//Create connections
            conn = DBConnectionFactory.getConnection();
//Create SQL String
            String sql = "Select * FROM Reservations WHERE LastName = ?";
            pstmt = conn.prepareStatement(sql);
            pstmt.setString(1, LastName);
//Excute SQL Statment
            rs = pstmt.executeQuery();
            rs.next();

//Get required data from Result set to create new Reservation class
            ReservationRN = new Reservation(rs.getInt("ReservationNumber"),
                    rs.getString("FirstName"),
                    rs.getString("LastName"),
                    rs.getInt("Occupants"),
                    rs.getInt("Smoking"),
                    rs.getString("CheckIn"),
                    rs.getString("CheckOut"),
                    rs.getString("Requests"));


        } catch (Exception e) {
            System.out.println("some error" + e.getMessage());

        } finally {
            DBConnectionFactory.close(conn);
            DBConnectionFactory.close(pstmt);
            DBConnectionFactory.close(rs);

        }

        return ReservationRN;

    }
}
