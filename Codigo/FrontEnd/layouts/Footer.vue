<template>
    <footer class="footer-area">
        <div class="container">
            <div class="row">
                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="single-footer-widget">
                        <div class="logo">
                            <nuxt-link to="/"><img src="../static/logo.png" alt="logo"></nuxt-link>
                        </div>

                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices gravida.</p>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="single-footer-widget">
                        <h3>Links Rápidos</h3>

                        <ul class="quick-links">
                            <li><nuxt-link to="/cart">Cart</nuxt-link></li>
                            <li><nuxt-link to="/contact">Entre em contato conosco</nuxt-link></li>
                        </ul>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="single-footer-widget">
                        <h3>Informações</h3>

                        <ul class="information-links">
                            <li><nuxt-link to="/login">Login</nuxt-link></li>
                            <li><nuxt-link to="/signup">Signup</nuxt-link></li>
                            <li><nuxt-link to="/contact">Entre em contato conosco</nuxt-link></li>
                        </ul>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="single-footer-widget">
                        <h3>Entre em contato conosco</h3>

                        <ul class="footer-contact-info">
                            <li><i class="fas fa-map-marker-alt"></i> Location: PUC Minas, Praça da Liberdade </li>
                            <li><i class="fas fa-phone"></i> Telefone: <a href="#">(+123) 456-7898</a></li>
                            <li><i class="far fa-envelope"></i> Email: <a href="#">support@support.com</a></li>
                            <li><i class="fas fa-fax"></i> Fax: <a href="#">+123456</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="copyright-area">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-6 col-md-6">
                        <p>Copyright &copy; {{ new Date().getFullYear() }} Carlos Germano. Todos os direitos reservados</p>
                    </div>

                    <div class="col-lg-6 col-md-6">
                        <ul class="payment-card">
                            <li><a href="#" target="_blank"><img src="../assets/img/visa.png" alt="image"></a></li>
                            <li><a href="#" target="_blank"><img src="../assets/img/mastercard.png" alt="image"></a></li>
                            <li><a href="#" target="_blank"><img src="../assets/img/mastercard2.png" alt="image"></a></li>
                            <li><a href="#" target="_blank"><img src="../assets/img/visa2.png" alt="image"></a></li>
                            <li><a href="#" target="_blank"><img src="../assets/img/expresscard.png" alt="image"></a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </footer>
</template>