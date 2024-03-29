/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DAO;

import Modelo.Alumnos;
import java.util.List;

/**
 *
 * @author emanu
 */
public interface AlumnosDAO {
    public void insertarAlumno (Alumnos alumnos);
    public void modificarAlumno (Alumnos alumnos);
    public void eliminarAlumno (Alumnos alumnos);
    public List<Alumnos> mostrarAlumnos();
}