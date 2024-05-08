/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Bean;

import DAO.AlumnosDAO;
import DAO.AlumnosDAOImplement;
import DAO.TrabajosDAO;
import DAO.TrabajosDAOImplement;
import Modelo.Alumnos;
import Modelo.Profesores;
import Modelo.Trabajos;
import java.util.List;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.faces.context.FacesContext;



/**
 *
 * @author sigar
 */
@ManagedBean
@ViewScoped
public class TrabajosBean {
    private Trabajos trabajos;
    private List<Trabajos> trabajosLista;
    private int noCuentaAlumno;
    private int noCuentaProfesor;
    private String password;

    public Trabajos getTrabajos() {
        return trabajos;
    }

    public void setTrabajos(Trabajos trabajos) {
        this.trabajos = trabajos;
    }

    public List<Trabajos> getTrabajosLista() {
        TrabajosDAO dao = new TrabajosDAOImplement();
        trabajosLista = dao.mostrarTrabajos();
        return trabajosLista;
    }

    public void setTrabajosLista(List<Trabajos> trabajosLista) {
        this.trabajosLista = trabajosLista;
    }

    public int getNoCuentaAlumno() {
        return noCuentaAlumno;
    }

    public void setNoCuentaAlumno(int noCuentaAlumno) {
        this.noCuentaAlumno = noCuentaAlumno;
    }

    public int getNoCuentaProfesor() {
        return noCuentaProfesor;
    }

    public void setNoCuentaProfesor(int noCuentaProfesor) {
        this.noCuentaProfesor = noCuentaProfesor;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
    
    
    public TrabajosBean() {
        trabajos = new Trabajos();
        TrabajosDAO dao = new TrabajosDAOImplement();
        trabajosLista = dao.mostrarTrabajos();
    }
    
    public void addMessage(String summary){
        FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_INFO, summary, null);
        FacesContext.getCurrentInstance().addMessage(null, message);
    }
    
    public void insertar(){
        TrabajosDAO dao = new TrabajosDAOImplement();
        
        Alumnos alumno = new Alumnos();
        alumno.setNoCuentaAlumno(noCuentaAlumno);
        trabajos.setAlumnos(alumno);
        
        Profesores profesor = new Profesores();
        profesor.setNoCuentaProfesor(noCuentaProfesor);
        trabajos.setProfesores(profesor);
        
        dao.insertarTrabajos(trabajos);
        trabajos = new Trabajos();
        addMessage("Trabajo Agregado A La Base De Datos...");
        dao.mostrarTrabajos();
    }
    public void modificar() {
        TrabajosDAO dao = new TrabajosDAOImplement();
        dao.modificarTrabajos(trabajos);
        trabajos = new Trabajos();
        addMessage("Trabajo Agregado A La Base De Datos...");
        dao.mostrarTrabajos();
    }
    public void eliminar(){
        TrabajosDAO dao = new TrabajosDAOImplement();
        if (password != null && !password.isEmpty()) {
            if (password.equals("admin123")) {
                dao.eliminarTrabajos(trabajos);
                    trabajos = new Trabajos();
                    addMessage("Trabajo Eliminado En La Base De Datos...");
                    trabajosLista = dao.mostrarTrabajos();
            } else {
                addMessage("Contraseña incorrecta. No se pudo eliminar el trabajo.");
                trabajosLista = dao.mostrarTrabajos();
            }
        } else {
            addMessage("Por favor, ingrese una contraseña.");
            trabajosLista = dao.mostrarTrabajos();
        }
        password = null;
    }

    
}
