/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Bean;

import Dao.AlumnosDAO;
import Dao.AlumnosDaoImplement;
import Modelo.Alumnos;
import java.util.List;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.faces.context.FacesContext;

/**
 *
 * @author emanu
 */
@ManagedBean
@ViewScoped
public class alumnosBean {

    private Alumnos alumnos;
    private List<Alumnos> alumnosLista;

    public Alumnos getAlumnos() {
        return alumnos;
    }

    public void setAlumnos(Alumnos alumnos) {
        this.alumnos = alumnos;
    }

    public List<Alumnos> getAlumnosLista() {
        AlumnosDAO dao = new AlumnosDaoImplement();
        alumnosLista = dao.mostrarAlumnos();
        return alumnosLista;
    }

    public void setAlumnosLista(List<Alumnos> alumnosLista) {
        this.alumnosLista = alumnosLista;
    }

    public void addMessage(String summary) {
        FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_INFO, summary, null);
        FacesContext.getCurrentInstance().addMessage(null, message);
    }

    public alumnosBean() {
        alumnos = new Alumnos();
    }
    
    public void insertar(){
        AlumnosDAO dao = new AlumnosDaoImplement();
        dao.insertarAlumno(alumnos);
        alumnos = new Alumnos();
        addMessage("Alumno Agregado A La Base De Datos...");
    }

    public void modificar(){
        AlumnosDAO dao = new AlumnosDaoImplement();
        dao.modificarAlumno(alumnos);
        alumnos = new Alumnos();
        addMessage("Alumno Modificado En La Base De Datos...");
    }
        public void eliminar(){
        AlumnosDAO dao = new AlumnosDaoImplement();
        dao.eliminarAlumno(alumnos);
        alumnos = new Alumnos();
        addMessage("Alumno Eliminado En La Base De Datos...");
    }
}
