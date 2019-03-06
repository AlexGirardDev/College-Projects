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
public class AddReservationServlet extends HttpServlet {

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
        //Get required varibales from HTML Page useing POST
        String FirstName = request.getParameter("firstname");
        String LastName = request.getParameter("lastname");
        String Occupant = request.getParameter("occupants");
        String Smoking = request.getParameter("smoking");
        String Requests = request.getParameter("requests");
        String Checkin = request.getParameter("checkin");
        String Checkout = request.getParameter("checkout");
        //Create DBMethods Objcts
        DBMethods db = new DBMethods();
        boolean diditadd;
//Excute DBMethods method to add reservation to database
        Reservation reservation = new Reservation(0, FirstName, LastName,
                Integer.parseInt(Occupant), Integer.parseInt(Smoking), Checkin, Checkout, Requests);




        diditadd = db.addReservation(reservation);

        try {
            /* TODO output your page here. You may use following sample code. */
            out.println("<html>");
            out.println("<head>");
            out.println("<title>SQL Motel</title>");
            out.println("</head>");
            out.println("<body>");
            out.println("<table border=2>");
            out.println("<tr><td colspan =2> Add Reservation/td></tr>");
            out.println("<tr><td>" + "First Name" + "</td><td>" + FirstName + "</td></tr>");
            out.println("<tr><td>" + "Last Name" + "</td><td>" + LastName + "</td></tr>");
            out.println("<tr><td>" + "Occupants" + "</td><td>" + Occupant + "</td></tr>");
            out.println("<tr><td>" + "Smoking?" + "</td><td>" + Smoking + "</td></tr>");
            out.println("<tr><td>" + "Requests" + "</td><td>" + Requests + "</td></tr>");
            out.println("<tr><td>" + "Check In" + "</td><td>" + Checkin + "</td></tr>");
            out.println("<tr><td>" + "Check Out" + "</td><td>" + Checkout + "</td></tr>");

            out.println("<tr><td>" + " Did it add?" + "</td><td>" + diditadd + "</td></tr>");

            out.println("</table>");


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
