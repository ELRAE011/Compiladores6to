package Modelo;
// Generated 28/03/2024 09:57:34 PM by Hibernate Tools 4.3.1


import java.util.Date;

/**
 * Trabajos generated by hbm2java
 */
public class Trabajos  implements java.io.Serializable {


     private Integer idTrabajo;
     private Alumnos alumnos;
     private Profesores profesores;
     private String tema;
     private Date fechaPresentacion;
     private Date fechaEntrega;
     private Date fechaPublicacion;

    public Trabajos() {
        alumnos = new Alumnos();
        profesores = new Profesores();
    }

    public Trabajos(Alumnos alumnos, Profesores profesores, String tema, Date fechaPresentacion, Date fechaEntrega, Date fechaPublicacion) {
       this.alumnos = alumnos;
       this.profesores = profesores;
       this.tema = tema;
       this.fechaPresentacion = fechaPresentacion;
       this.fechaEntrega = fechaEntrega;
       this.fechaPublicacion = fechaPublicacion;
    }
   
    public Integer getIdTrabajo() {
        return this.idTrabajo;
    }
    
    public void setIdTrabajo(Integer idTrabajo) {
        this.idTrabajo = idTrabajo;
    }
    public Alumnos getAlumnos() {
        return this.alumnos;
    }
    
    public void setAlumnos(Alumnos alumnos) {
        this.alumnos = alumnos;
    }
    public Profesores getProfesores() {
        return this.profesores;
    }
    
    public void setProfesores(Profesores profesores) {
        this.profesores = profesores;
    }
    public String getTema() {
        return this.tema;
    }
    
    public void setTema(String tema) {
        this.tema = tema;
    }
    public Date getFechaPresentacion() {
        return this.fechaPresentacion;
    }
    
    public void setFechaPresentacion(Date fechaPresentacion) {
        this.fechaPresentacion = fechaPresentacion;
    }
    public Date getFechaEntrega() {
        return this.fechaEntrega;
    }
    
    public void setFechaEntrega(Date fechaEntrega) {
        this.fechaEntrega = fechaEntrega;
    }
    public Date getFechaPublicacion() {
        return this.fechaPublicacion;
    }
    
    public void setFechaPublicacion(Date fechaPublicacion) {
        this.fechaPublicacion = fechaPublicacion;
    }




}


