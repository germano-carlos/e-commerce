<template>
    <div class="col-lg-12 col-md-12">
        <div class="tab products-details-tab">
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <ul class="tabs">
                        <li><a href="#">
                            <div class="dot"></div> Descrição
                        </a></li>
                    </ul>
                </div>

                <div class="col-lg-12 col-md-12">
                    <div class="tab_content">
                        <div class="tabs_item">
                            <div class="products-details-tab-content" v-html="descricao">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { defineComponent } from '@vue/composition-api'

export default defineComponent({
    props: ['descricao']
})
</script>
