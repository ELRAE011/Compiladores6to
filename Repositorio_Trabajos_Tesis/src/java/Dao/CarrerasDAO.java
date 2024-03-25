/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Dao;

import Modelo.Carreras;
import java.util.List;

/**
 *
 * @author emanu
 */
public interface CarrerasDAO {
    public void insertarCarrera(Carreras carreras);
    public void modificarCarrera(Carreras carreras);
    public void eliminarCarrera(Carreras carreras);
    public List<Carreras> mostrarCarreras();
}
