/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Alex
 */
public class QueryReservationByLastNameServlet extends HttpServlet {

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
            DBMethods dbm = new DBMethods();
            String LastName = request.getParameter("lastname");

            Reservation reservation = dbm.getReservation(LastName);



            /* TODO output your page here. You may use following sample code. */
            out.println("<html>");
            out.println("<head>");
            out.println("<title>SQL Motel</title>");
            out.println("</head>");
            out.println("<body>");
            
            out.println("<h2>Find Reservation by Last Name/h2>");
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


            out.println("<tr>");

            System.out.println(reservation);
            out.println("<td>" + reservation.getReservationNumber() + "</td>");
            out.println("<td>" + reservation.getFirstName() + "</td>");
            out.println("<td>" + reservation.getLastName() + "</td>");
            out.println("<td>" + reservation.getOccupants() + "</td>");
            out.println("<td>" + reservation.getSmoking() + "</td>");
            out.println("<td>" + reservation.getCheckIn() + "</td>");
            out.println("<td>" + reservation.getCheckOut() + "</td>");
            out.println("<td>" + reservation.getRequests() + "</td>");
            out.println("</tr>");






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
