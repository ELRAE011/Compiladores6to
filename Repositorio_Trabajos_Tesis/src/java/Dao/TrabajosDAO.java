/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Dao;

import Modelo.Trabajos;
import java.util.List;

/**
 *
 * @author emanu
 */
public interface TrabajosDAO {
    public void insertarTrabajos (Trabajos trabajo);
    public void modificarTrabajos (Trabajos trabajo);
    public void eliminarTrabajos (Trabajos trabajo);
    public List<Trabajos> mostrarTrabajos();
}
