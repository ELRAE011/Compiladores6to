/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Dao;

import Modelo.Profesor;
import java.util.List;

/**
 *
 * @author emanu
 */
public interface ProfesorDAO {
    public void insertarProfesor(Profesor profesor);
    public void ModificarProfesor(Profesor profesor);
    public void eliminarProfesor(Profesor profesor);
    public List<Profesor> mostrarProfesores();
}
