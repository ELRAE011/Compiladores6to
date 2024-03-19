/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Dao;

import Modelo.Profesor;
import Persistencia.NewHibernateUtil;
import java.util.List;
import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

/**
 *
 * @author emanu
 */
public class ProfesorDaoImplement implements ProfesorDAO{

    @Override
    public void insertarProfesor(Profesor profesor) {
       Session session = null;
        try {
            session = NewHibernateUtil.getSessionFactory().openSession();
            session.beginTransaction();
            session.save(profesor);
            session.getTransaction().commit();
        } catch (HibernateException e) {
            System.out.println(e.getMessage());
            session.getTransaction().rollback();
        }finally{
            if(session != null){
                session.close();
            }
        }
    }

    @Override
    public void ModificarProfesor(Profesor profesor) {
        Session session = null;
        try {
            session = NewHibernateUtil.getSessionFactory().openSession();
            session.beginTransaction();
            session.update(profesor);
            session.getTransaction().commit();
        } catch (HibernateException e) {
            System.out.println(e.getMessage());
            session.getTransaction().rollback();
        }finally{
            if(session != null){
                session.close();
            }
        }
    }

    @Override
    public void eliminarProfesor(Profesor profesor) {
        Session session = null;
        try {
            session = NewHibernateUtil.getSessionFactory().openSession();
            session.beginTransaction();
            session.delete(profesor);
            session.getTransaction().commit();
        } catch (HibernateException e) {
            System.out.println(e.getMessage());
            session.getTransaction().rollback();
        }finally{
            if(session != null){
                session.close();
            }
        }
    }

    @Override
    public List<Profesor> mostrarProfesores() {
        Session session = null;
        List<Profesor> lista = null;
        try {
            session = NewHibernateUtil.getSessionFactory().openSession();
            Query query = session.createQuery("from Profesor");
            lista = (List<Profesor>) query.list();
        } catch (HibernateException e) {
            System.out.println(e.getMessage());
        }finally{
            if(session != null){
                session.close();
            }
        }
        return lista;
    }
    
}
