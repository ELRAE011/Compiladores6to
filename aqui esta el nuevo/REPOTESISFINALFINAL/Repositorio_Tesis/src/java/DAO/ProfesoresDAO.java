/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DAO;

import Modelo.Profesores;
import java.util.List;

/**
 *
 * @author emanu
 */
public interface ProfesoresDAO {
    public void insertarProfesor(Profesores profesores);
    public void ModificarProfesor(Profesores profesores);
    public void eliminarProfesor(Profesores profesores);
    public List<Profesores> mostrarProfesores();
}
