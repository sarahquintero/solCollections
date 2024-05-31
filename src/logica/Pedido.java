package logica;

import java.util.LinkedList;

public abstract class Pedido {

    private Cliente cliente;
    private LinkedList<Comida> productos;

    public Pedido() {
        this.productos = new LinkedList<>();

    }

    public Cliente getCliente() {
        return cliente;
    }

    public void setCliente(Cliente cliente) {
        this.cliente = cliente;
    }

    public LinkedList<Comida> getProductos() {
        return productos;
    }

    public void setProductos(LinkedList<Comida> productos) {
        this.productos = productos;
    }

    //Metodos para el carro
    public void añadirProducto(Comida objProducto) {
        productos.add(objProducto);
    }

    public void quitarProducto(Comida objProducto) {
        productos.remove(objProducto);
    }

    public boolean quitarProducto(int producto, int cantidadEliminar) throws ExcepcionCantidadInvalida {
        for (int i = 0; i < productos.size(); i++) {
            if (productos.get(i).getCodigo() == producto) {
                if (cantidadEliminar <= 0 || cantidadEliminar > productos.get(i).getCantidadVendida()) {
                    throw new ExcepcionCantidadInvalida("La cantidad a eliminar es inconsistente.");
                } else if (cantidadEliminar == productos.get(i).getCantidadVendida()) {
                    quitarProducto(productos.get(i));
                    return true;
                } else {
                    int nuevaCantidad = productos.get(i).getCantidadVendida() - cantidadEliminar;
                    productos.get(i).setCantidadVendida(nuevaCantidad);
                    return true;
                }
            }
        }
        throw new ExcepcionCantidadInvalida("El código de producto ingresado no está en su carrito");
    }

    public String mostrarCarrito() {
        StringBuilder sb = new StringBuilder();

        if (productos.isEmpty()) {
            sb.append("No hay productos en el carrito");
        } else {
            sb.append("-------------------------------------------------\n");
            sb.append(String.format("| %-5s | %-20s | %-10s | %-10s |\n", "CÓDIGO", "PRODUCTO", "PRECIO", "CANTIDAD"));
            sb.append("-------------------------------------------------\n");

            for (Comida producto : productos) {
                sb.append(String.format("| %-5d | %-20s | $%-9.2f | %-10d |\n",
                        producto.getCodigo(), producto.getNombre(), producto.getPrecio(), producto.getCantidadVendida()));
            }

            sb.append("-------------------------------------------------\n");
            sb.append(String.format("| %-36s | $%-9.2f |\n", "COSTO TOTAL + IMPUESTOS", calcularCostoTotal()));
            sb.append("-------------------------------------------------\n");
        }

        return sb.toString();
    }

    public double calcularCostoTotal() {
        double costoTotal = 0;

        for (Comida producto : productos) {
            if (producto instanceof ICobrar) {
                ICobrar productoCobrable = (ICobrar) producto;
                costoTotal += productoCobrable.calcularCosto() * producto.getCantidadVendida();
            }
        }

        return costoTotal;
    }

}
