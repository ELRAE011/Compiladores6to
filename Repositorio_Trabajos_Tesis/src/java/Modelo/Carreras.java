package Modelo;
// Generated 18/03/2024 12:13:21 PM by Hibernate Tools 4.3.1


import java.util.HashSet;
import java.util.Set;

/**
 * Carreras generated by hbm2java
 */
public class Carreras  implements java.io.Serializable {


     private String carrera;
     private String generacion;
     private Set<Profesor> profesors = new HashSet<Profesor>(0);
     private Set<Alumnos> alumnosesForCarrera = new HashSet<Alumnos>(0);
     private Set<Alumnos> alumnosesForGeneracion = new HashSet<Alumnos>(0);
     private Set<Trabajos> trabajosesForGeneracion = new HashSet<Trabajos>(0);
     private Set<Trabajos> trabajosesForCarrera = new HashSet<Trabajos>(0);

    public Carreras() {
    }

	
    public Carreras(String carrera) {
        this.carrera = carrera;
    }
    public Carreras(String carrera, String generacion, Set<Profesor> profesors, Set<Alumnos> alumnosesForCarrera, Set<Alumnos> alumnosesForGeneracion, Set<Trabajos> trabajosesForGeneracion, Set<Trabajos> trabajosesForCarrera) {
       this.carrera = carrera;
       this.generacion = generacion;
       this.profesors = profesors;
       this.alumnosesForCarrera = alumnosesForCarrera;
       this.alumnosesForGeneracion = alumnosesForGeneracion;
       this.trabajosesForGeneracion = trabajosesForGeneracion;
       this.trabajosesForCarrera = trabajosesForCarrera;
    }
   
    public String getCarrera() {
        return this.carrera;
    }
    
    public void setCarrera(String carrera) {
        this.carrera = carrera;
    }
    public String getGeneracion() {
        return this.generacion;
    }
    
    public void setGeneracion(String generacion) {
        this.generacion = generacion;
    }
    public Set<Profesor> getProfesors() {
        return this.profesors;
    }
    
    public void setProfesors(Set<Profesor> profesors) {
        this.profesors = profesors;
    }
    public Set<Alumnos> getAlumnosesForCarrera() {
        return this.alumnosesForCarrera;
    }
    
    public void setAlumnosesForCarrera(Set<Alumnos> alumnosesForCarrera) {
        this.alumnosesForCarrera = alumnosesForCarrera;
    }
    public Set<Alumnos> getAlumnosesForGeneracion() {
        return this.alumnosesForGeneracion;
    }
    
    public void setAlumnosesForGeneracion(Set<Alumnos> alumnosesForGeneracion) {
        this.alumnosesForGeneracion = alumnosesForGeneracion;
    }
    public Set<Trabajos> getTrabajosesForGeneracion() {
        return this.trabajosesForGeneracion;
    }
    
    public void setTrabajosesForGeneracion(Set<Trabajos> trabajosesForGeneracion) {
        this.trabajosesForGeneracion = trabajosesForGeneracion;
    }
    public Set<Trabajos> getTrabajosesForCarrera() {
        return this.trabajosesForCarrera;
    }
    
    public void setTrabajosesForCarrera(Set<Trabajos> trabajosesForCarrera) {
        this.trabajosesForCarrera = trabajosesForCarrera;
    }




}


