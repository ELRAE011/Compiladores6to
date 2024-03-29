/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DAO;

import Modelo.Profesores;
import Persistencia.NewHibernateUtil;
import java.util.List;
import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

/**
 *
 * @author sigar
 */
public class ProfesoresDaoImplements implements ProfesoresDAO{

    @Override
    public void insertarProfesor(Profesores profesores) {
               Session session = null;
        try {
            session = NewHibernateUtil.getSessionFactory().openSession();
            session.beginTransaction();
            session.save(profesores);
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
    public void ModificarProfesor(Profesores profesores) {
        Session session = null;
        try {
            session = NewHibernateUtil.getSessionFactory().openSession();
            session.beginTransaction();
            session.update(profesores);
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
    public void eliminarProfesor(Profesores profesores) {
        Session session = null;
        try {
            session = NewHibernateUtil.getSessionFactory().openSession();
            session.beginTransaction();
            session.delete(profesores);
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
    public List<Profesores> mostrarProfesores() {
        Session session = null;
        List<Profesores> lista = null;
        try {
            session = NewHibernateUtil.getSessionFactory().openSession();
            Query query = session.createQuery("from profesores");
            lista = (List<Profesores>) query.list();
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
