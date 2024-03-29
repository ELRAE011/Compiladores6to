/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Bean;

import Dao.AlumnosDAO;
import Dao.AlumnosDaoImplement;
import Modelo.Alumnos;
import Modelo.Carreras;
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
    private String carrera;
    private String generacion;
    
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

    public String getCarrera() {
        return carrera;
    }

    public void setCarrera(String carrera) {
        this.carrera = carrera;
    }

    public String getGeneracion() {
        return generacion;
    }

    public void setGeneracion(String generacion) {
        this.generacion = generacion;
    }

    
    public void addMessage(String summary) {
        FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_INFO, summary, null);
        FacesContext.getCurrentInstance().addMessage(null, message);
    }

    public alumnosBean() {
        alumnos = new Alumnos();
        AlumnosDAO dao = new AlumnosDaoImplement();
        alumnosLista = dao.mostrarAlumnos();
    }
    
    public void insertar(){
        AlumnosDAO dao = new AlumnosDaoImplement();
        
        Carreras carrera = new Carreras();
        carrera.setCarrera(this.carrera);
        alumnos.setCarrerasByCarrera(carrera);
                
        carrera.setGeneracion(this.generacion);
        alumnos.setCarrerasByGeneracion(carrera);
        
        dao.insertarAlumno(alumnos);
        alumnos = new Alumnos();
        addMessage("Alumno Agregado A La Base De Datos...");
        dao.mostrarAlumnos();
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
