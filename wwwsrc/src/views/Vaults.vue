<template>
    <div>
        <router-link :to="{name: 'home'}">Home Page</router-link>
         <form @submit.prevent="createVault()">
            <input type="text" v-model="newVault.name" placeholder="name">
            <input type="text" v-model="newVault.description" placeholder="description">
            <button class="btn btn-primary" type="submit">Create New Vault</button>
        </form>
        <div class="card" style="width: 18rem;" v-for="vault in vaults" :key="vault.id">
        <div class="card-body">
            <h5 class="card-title">{{vault.name}}</h5>
            <p class="card-text">{{vault.description}}</p>
             <button class="btn btn-success" @click="enterVault(vault.id)">enterVault</button>
            <button class="btn btn-danger" @click="deleteVault(vault.id)">delete me</button>
        </div>
        </div>

    </div>
</template>

<script>
    
export default {
    name: 'Vaults', 
    mounted() {
        this.$store.dispatch("getUserVaults")
        //get all vaults
    },
    data(){
        return {
            newVault: {
                name: "", 
                description: ""
            }
        }
    }, 
    computed: {
        user() {
            return this.$store.state.user

        }, 
        vaults(){
            return this.$store.state.vaults
        }
    }, 
    components: {
        
    }, 
    methods: {
        createVault() {
            this.$store.dispatch("createVault", this.newVault)
        }, 
        enterVault(id){
            this.$store.dispatch("getVault", id) 
            this.$store.dispatch("getVaultKeeps", id) 
        }, 
        deleteVault(id) {
            this.$store.dispatch("deleteVault", id)
        }
    }
}
</script>

<style>

</style>
