<template>
    <div class="row">

            <div class="card" style="width: 18rem;" v-for="keep in keeps" :key="keep.id">
            <img :src="keep.img"  class="card-img-top" alt="..." />
                <div class="card-body">
                    <h5 class="card-title">{{keep.name}}</h5>
                    <p class="card-text">{{keep.description}}</p>
                    <!-- keep views + keep shares +  -->
                
                </div>
            </div>
        
    </div>
</template>

<script>
export default {
name: "publickeep", 
data() {
        return{
            selected:""
        }
}, 
computed: {
    keeps() {
        return this.$store.state.keeps
    }
    //vaults() {return this.$store.vaults} ?Vaults go here?
},

    methods: {
        
    } 
}
</script>

<style></style>
