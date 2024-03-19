/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Bean;


import Dao.CarrerasDAO;
import Dao.CarrerasDaoImplement;
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
public class carrerasBean {

    private Carreras carreras;
    private List<Carreras> carrerasLista;

    public Carreras getCarreras() {
        return carreras;
    }

    public void setCarreras(Carreras carreras) {
        this.carreras = carreras;
    }

    public List<Carreras> getCarrerasLista() {
        CarrerasDAO dao = new CarrerasDaoImplement();
        carrerasLista = dao.mostrarCarreras();
        return carrerasLista;
    }

    public void setCarrerasLista(List<Carreras> carrerasLista) {
        this.carrerasLista = carrerasLista;
    }
    
    public void addMessage(String summary){
        FacesMessage message = new FacesMessage(FacesMessage.SEVERITY_INFO, summary, null);
        FacesContext.getCurrentInstance().addMessage(null, message);
    }
    
    public carrerasBean() {
        carreras = new Carreras();
    }
  
    public void insertar(){
        CarrerasDAO dao = new CarrerasDaoImplement();
        dao.insertarCarrera(carreras);
        carreras = new Carreras();
        addMessage("Carrera Agregada A La Base De Datos...");
    }
    
    public void modificar(){
        CarrerasDAO dao = new CarrerasDaoImplement();
        dao.modificarCarrera(carreras);
        carreras = new Carreras();
        addMessage("Carrera Modificada En La Base De Datos...");
    }
    
    public void eliminar(){
        CarrerasDAO dao = new CarrerasDaoImplement();
        dao.eliminarCarrera(carreras);
        carreras = new Carreras();
        addMessage("Carrera Eliminada En La Base De Datos...");
    }
}
