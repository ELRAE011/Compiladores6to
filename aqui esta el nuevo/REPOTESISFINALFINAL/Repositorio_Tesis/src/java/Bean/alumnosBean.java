/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Bean;

import DAO.AlumnosDAO;
import DAO.AlumnosDAOImplement;
import Modelo.Alumnos;
import Modelo.Carreras;
import java.util.List;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.faces.context.FacesContext;


@ManagedBean
@ViewScoped
public class alumnosBean {

    private Alumnos alumnos;
    private List<Alumnos> alumnosLista;
    private int id_carrera;
    private String password;

    public Alumnos getAlumnos() {
        return alumnos;
    }

    public void setAlumnos(Alumnos alumnos) {
        this.alumnos = alumnos;
    }

    public List<Alumnos> getAlumnosLista() {
        AlumnosDAO dao = new AlumnosDAOImplement();
        alumnosLista = dao.mostrarAlumnos();
        return alumnosLista;
    }

    public void setAlumnosLista(List<Alumnos> alumnosLista) {
        this.alumnosLista = alumnosLista;
    }

    public int getId_carrera() {
        return id_carrera;
    }

    public void setId_carrera(int id_carrera) {
        this.id_carrera = id_carrera;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
    
    public void addMessage(String summary) {
        FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_INFO, summary, null);
        FacesContext.getCurrentInstance().addMessage(null, message);
    }
    
    public alumnosBean() {
        alumnos = new Alumnos();
        AlumnosDAO dao = new AlumnosDAOImplement();
        alumnosLista = dao.mostrarAlumnos();
    }
    
    public void insertar(){
        AlumnosDAO dao = new AlumnosDAOImplement();
        
        Carreras carrera = new Carreras();
        carrera.setCarreraId(id_carrera);
        alumnos.setCarreras(carrera);
        
        dao.insertarAlumno(alumnos);
        alumnos = new Alumnos();
        addMessage("Alumno Agregado A La Base De Datos...");
        dao.mostrarAlumnos();
    }

    public void modificar(){
        AlumnosDAO dao = new AlumnosDAOImplement();
        dao.modificarAlumno(alumnos);
        alumnos = new Alumnos();
        addMessage("Alumno Modificado En La Base De Datos...");
    }
    public void eliminar(){
        AlumnosDAO dao = new AlumnosDAOImplement();
        if (password != null && !password.isEmpty()) {
            if (password.equals("admin123")) {
                dao.eliminarAlumno(alumnos);
                    alumnos = new Alumnos();
                    addMessage("Alumno Eliminado En La Base De Datos...");
                    alumnosLista = dao.mostrarAlumnos();
            } else {
                addMessage("Contraseña incorrecta. No se pudo eliminar el alumno.");
                alumnosLista = dao.mostrarAlumnos();
            }
        } else {
            addMessage("Por favor, ingrese una contraseña.");
            alumnosLista = dao.mostrarAlumnos();
        }
        password = null;
    }
    
}
