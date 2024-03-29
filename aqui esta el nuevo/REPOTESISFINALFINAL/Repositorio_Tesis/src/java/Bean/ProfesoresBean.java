/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Bean;

import DAO.ProfesoresDAO;
import DAO.ProfesoresDaoImplements;
import Modelo.Carreras;
import Modelo.Profesores;
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
public class ProfesoresBean {
    private Profesores profesores;
    private List <Profesores> profesoresLista;
    private int carrera_id;
    private String password;

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
    
    public int getCarrera_id() {
        return carrera_id;
    }

    public void setCarrera_id(int carrera_id) {
        this.carrera_id = carrera_id;
    }
    
    public Profesores getProfesores() {
        return profesores;
    }

    public void setProfesores(Profesores profesores) {
        this.profesores = profesores;
    }

    public List<Profesores> getProfesoresLista() {
        ProfesoresDAO dao = new ProfesoresDaoImplements();
        profesoresLista = dao.mostrarProfesores();
        return profesoresLista;
    }

    public void setProfesoresLista(List<Profesores> profesoresLista) {
        this.profesoresLista = profesoresLista;
    }
    public void addMessage(String summary) {
        FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_INFO, summary, null);
        FacesContext.getCurrentInstance().addMessage(null, message);
    }
    
    public ProfesoresBean() {
        profesores = new Profesores();
        ProfesoresDAO dao = new ProfesoresDaoImplements();
        profesoresLista = dao.mostrarProfesores();
    }
    
    public void insertar(){
        ProfesoresDAO dao = new ProfesoresDaoImplements();
        
        Carreras carrera = new Carreras();
        carrera.setCarreraId(carrera_id);
        profesores.setCarreras(carrera);
        
        dao.insertarProfesor(profesores);
        profesores = new Profesores();
        addMessage("Profesor Agregado A La Base De Datos...");
        dao.mostrarProfesores();
    }

    public void modificar(){
        ProfesoresDAO dao = new ProfesoresDaoImplements();
        dao.ModificarProfesor(profesores);
        profesores = new Profesores();
        addMessage("Profesor Modificado En La Base De Datos...");
    }
    public void eliminar(){
        ProfesoresDAO dao = new ProfesoresDaoImplements();
        if (password != null && !password.isEmpty()) {
            if (password.equals("admin123")) {
                dao.eliminarProfesor(profesores);
                    profesores = new Profesores();
                    addMessage("Profesor Eliminado En La Base De Datos...");
                    profesoresLista = dao.mostrarProfesores();
            } else {
                addMessage("Contraseña incorrecta. No se pudo eliminar al profesor.");
                profesoresLista = dao.mostrarProfesores();
            }
        } else {
            addMessage("Por favor, ingrese una contraseña.");
            profesoresLista = dao.mostrarProfesores();
        }
        password = null;
    }
    
}
