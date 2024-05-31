
package logica;

import java.util.LinkedList;


public class Cliente {
    
protected String nombre;
    protected Pedido pedido;
    private LinkedList<Comida> productosComprados;

    public Cliente(String nombre, Pedido carrito) {
        this.nombre = nombre;
        this.pedido = carrito;
        this.productosComprados = new LinkedList<>();
    }

    public LinkedList<Comida> getProductosComprados() {
        return productosComprados;
    }

    public void setProductosComprados(LinkedList<Comida> productosComprados) {
        this.productosComprados = productosComprados;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public Pedido getCarrito() {
        return pedido;
    }

    public void setCarrito(Pedido carrito) {
        this.pedido = carrito;
    }

    public void addCarrito(Pedido objCarrito) {
        this.pedido = objCarrito;
    }
}