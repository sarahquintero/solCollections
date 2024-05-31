package logica;

import java.util.LinkedList;
import java.util.List;

public class Restaurante {

    private Cliente cliente;
    private String nombre;
    private List<Comida> productos;
    private List<Cliente> clientes;

    public Restaurante(String nombre, List<Comida> productos, List<Cliente> clientes) {
        this.nombre = nombre;
        this.productos = new LinkedList<>(productos);
        this.clientes = new LinkedList<>(clientes);
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public List<Comida> getProductos() {
        return productos;
    }

    public void setProductos(List<Comida> productos) {
        this.productos = productos;
    }

    public List<Cliente> getClientes() {
        return clientes;
    }

    public void setClientes(List<Cliente> clientes) {
        this.clientes = clientes;
    }

    public void asignarCodigos() {
        for (int i = 0; i < productos.size(); i++) {
            productos.get(i).setCodigo(i);
        }
    }

    public void realizarCompra() {
        for (Comida productoFisico : cliente.getCarrito().getProductos()) {
            cliente.getProductosComprados().add(productoFisico);
        }
    }

    public void setCliente(Cliente cliente) {
        this.cliente = cliente;
    }

    public Cliente getCliente() {
        return cliente;
    }

    public String mostrarClientes() {
        StringBuilder sb = new StringBuilder();
        sb.append("--------------------------------------------------------------------------\n");
        sb.append(String.format("| %-20s | %-25s | %-15s |\n", "CLIENTE", "PRODUCTO", "COSTO TOTAL + IMPUESTO"));
        sb.append("--------------------------------------------------------------------------\n");

        for (Cliente cliente : clientes) {
            for (Comida producto : cliente.getProductosComprados()) {
                sb.append(String.format("| %-20s | %-25s | $%-9.2f Cantidad: %-6d |\n",
                        "", producto.getNombre(), producto.getPrecio(), producto.getCantidadVendida()));
            }
            sb.append(String.format("| %-20s | %-25s | $%-14.2f |\n", cliente.getNombre(), "", cliente.getCarrito().calcularCostoTotal()));

            sb.append("--------------------------------------------------------------------------\n");
        }

        return sb.toString();
    }

    public String mostrarProductos() {
        StringBuilder sb = new StringBuilder();
        String formatoCabecera = "%-6s %-12s %-10s\n";
        String formatoProducto = "%-6d %-12s $%-9.2f\n";

        sb.append(String.format(formatoCabecera, "COD", "PRODUCTO", "PRECIO"));

        for (Comida producto : productos) {
            sb.append(String.format(formatoProducto, producto.getCodigo(), producto.getNombre(), producto.getPrecio()));
        }

        return sb.toString();
    }

}
