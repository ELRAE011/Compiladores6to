/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DAO;

import Modelo.Trabajos;
import Persistencia.NewHibernateUtil;
import java.util.List;
import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

/**
 *
 * @author sigar
 */
public class TrabajosDAOImplement implements TrabajosDAO{

    @Override
    public void insertarTrabajos(Trabajos trabajo) {
        Session session = null;
        try {
            session = NewHibernateUtil.getSessionFactory().openSession();
            session.beginTransaction();
            session.save(trabajo);
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
    public void modificarTrabajos(Trabajos trabajo) {
        Session session = null;
        try {
            session = NewHibernateUtil.getSessionFactory().openSession();
            session.beginTransaction();
            session.update(trabajo);
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
    public void eliminarTrabajos(Trabajos trabajo) {
        Session session = null;
        try {
            session = NewHibernateUtil.getSessionFactory().openSession();
            session.beginTransaction();
            session.delete(trabajo);
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
    public List<Trabajos> mostrarTrabajos() {
       Session session = null;
        List<Trabajos> lista = null;
        try {
            session = NewHibernateUtil.getSessionFactory().openSession();
            Query query = session.createQuery("from Trabajos");
            lista = (List<Trabajos>) query.list();
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
