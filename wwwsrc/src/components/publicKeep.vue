<template>
    <div class="row">

            <div class="card" style="width: 18rem;" v-for="keep in keeps" :key="keep.id">
            <img :src="keep.img"  class="card-img-top" alt="..." />
                <div class="card-body">
                    <h5 class="card-title">{{keep.name}}</h5>
                    <p class="card-text">{{keep.description}}</p>
                    
                    <form @submit.prevent="addKeepToVault(keep.id)">
                    <select v-model="selected">
                        <option disabled value>Add Keep To Secret Vault</option>
                        <option v-bind:value="vault.id" v-for="vault in vaults" :key="vault.id">{{vault.name}}</option>
                    </select>
                    <button type="submit">Secret Submit Button</button>
                    </form>

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
        return this.$store.state.publicKeeps
    }, 
    vaults() {
        return this.$store.state.vaults
    }
    
},
mounted() {
    this.$store.dispatch("getUserVaults")
    this.$store.dispatch("getPublicKeeps")
},

methods: {
        
        addKeepToVault(deliverydata){
            
            let ndata = {
                vaultId: this.selected,
                keepId: deliverydata
            }
            this.$store.dispatch("createVaultKeep", ndata)
        }
} 
}
</script>

<style>

</style>
