/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Alex
 */
public class Reservation {

    private int ReservationNumber;
    private String FirstName;
    private String LastName;
    private int Occupants;
    private int Smoking;
    private String CheckIn;
    private String CheckOut;
    private String Requests;

    public Reservation(int ReservationNumber, String FirstName,
            String LastName, int Occupants, int Smoking,
            String CheckIn, String CheckOut, String Requests) {
        this.ReservationNumber = ReservationNumber;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Occupants = Occupants;
        this.Smoking = Smoking;
        this.CheckIn = CheckIn;
        this.CheckOut = CheckOut;
        this.Requests = Requests;


    }

    /**
     * @return the ReservationNumber
     */
    public int getReservationNumber() {
        return ReservationNumber;
    }

    /**
     * @param ReservationNumber the ReservationNumber to set
     */
    public void setReservationNumber(int ReservationNumber) {
        this.ReservationNumber = ReservationNumber;
    }

    /**
     * @return the FirstName
     */
    public String getFirstName() {
        return FirstName;
    }

    /**
     * @param FirstName the FirstName to set
     */
    public void setFirstName(String FirstName) {
        this.FirstName = FirstName;
    }

    /**
     * @return the LastName
     */
    public String getLastName() {
        return LastName;
    }

    /**
     * @param LastName the LastName to set
     */
    public void setLastName(String LastName) {
        this.LastName = LastName;
    }

    /**
     * @return the Occupants
     */
    public int getOccupants() {
        return Occupants;
    }

    /**
     * @param Occupants the Occupants to set
     */
    public void setOccupants(int Occupants) {
        this.Occupants = Occupants;
    }

    /**
     * @return the Smoking
     */
    public int getSmoking() {
        return Smoking;
    }

    /**
     * @param Smoking the Smoking to set
     */
    public void setSmoking(int Smoking) {
        this.Smoking = Smoking;
    }

    /**
     * @return the CheckIn
     */
    public String getCheckIn() {
        return CheckIn;
    }

    /**
     * @param CheckIn the CheckIn to set
     */
    public void setCheckIn(String CheckIn) {
        this.CheckIn = CheckIn;
    }

    /**
     * @return the CheckOut
     */
    public String getCheckOut() {
        return CheckOut;
    }

    /**
     * @param CheckOut the CheckOut to set
     */
    public void setCheckOut(String CheckOut) {
        this.CheckOut = CheckOut;
    }

    /**
     * @return the Requests
     */
    public String getRequests() {
        return Requests;
    }

    /**
     * @param Requests the Requests to set
     */
    public void setRequests(String Requests) {
        this.Requests = Requests;
    }
}
