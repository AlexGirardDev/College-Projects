/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Alex
 */
public class QueryAllReservationsServlet extends HttpServlet {

    /**
     * Processes requests for both HTTP
     * <code>GET</code> and
     * <code>POST</code> methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        try {
//Create DBMethods object
            DBMethods dbm = new DBMethods();
            
            //Create Array List and get ArrayList from DBMEthods
            ArrayList<Reservation> reservationlist = dbm.getReservations();






            /* TODO output your page here. You may use following sample code. */
            out.println("<html>");
            out.println("<head>");
            out.println("<title>SQL Motel</title>");
            out.println("</head>");
            out.println("<body>");
            
            out.println("<h2>All Reservations</h2>");
            out.println("<table border=2");
            out.println("<tr>");
            out.println("<td>Reservation Number</td>");
            out.println("<td>First Name</td>");
            out.println("<td>Last Name</td>");
            out.println("<td>Occupants</td>");
            out.println("<td>Smoking Room</td> ");
            out.println("<td>Check in (yyyy-MM-dd HH:mm:ss) </td>");
            out.println("<td>Check out (yyyy-MM-dd HH:mm:ss) </td>");
            out.println("<td>Requests </td>");
            out.println("</tr>");
//Create Loop to print out entire arraylist
            for (int i = 0; i < reservationlist.size(); i++) {

                out.println("<tr>");

                System.out.println(reservationlist.get(i));
                out.println("<td>" + reservationlist.get(i).getReservationNumber() + "</td>");
                out.println("<td>" + reservationlist.get(i).getFirstName() + "</td>");
                out.println("<td>" + reservationlist.get(i).getLastName() + "</td>");
                out.println("<td>" + reservationlist.get(i).getOccupants() + "</td>");
                out.println("<td>" + reservationlist.get(i).getSmoking() + "</td>");
                out.println("<td>" + reservationlist.get(i).getCheckIn() + "</td>");
                out.println("<td>" + reservationlist.get(i).getCheckOut() + "</td>");
                out.println("<td>" + reservationlist.get(i).getRequests() + "</td>");
                out.println("</tr>");



            }





            out.println("</body>");
            out.println("</html>");
        } finally {
            out.close();
        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP
     * <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP
     * <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>
}
